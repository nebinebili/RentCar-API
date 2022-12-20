using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImageDto carImageDto)
        {
            IResult result = BusinessRules.Run(CheckImageCountExceed(carImageDto.CarId));
            if (result != null)
            {
                return result;
            }
            var carImage = new CarImage()
            {
                CarId = carImageDto.CarId,
                ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath),
                Date = DateTime.Now,
            };
            
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImageUpdateDeleteDto carImage)
        {
            var deletedCarImage = _carImageDal.Get(c => c.Id == carImage.Id);
            _fileHelper.Delete(PathConstants.ImagesPath+ deletedCarImage.ImagePath);
            _carImageDal.Delete(deletedCarImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(IFormFile file, CarImageUpdateDeleteDto carImage)
        {
            var updatedCarImage = _carImageDal.Get(c => c.Id == carImage.Id);
            updatedCarImage.ImagePath=_fileHelper.Update(file, PathConstants.ImagesPath+updatedCarImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(updatedCarImage);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            if (_carImageDal.GetAll().Any(c => c.CarId == carId))
            { 
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.CarImageListed);
            }
            return new ErrorDataResult<List<CarImage>>(Messages.IdNotFound);
        }

        public IResult CheckImageCountExceed(int carId) 
        {
            var result = _carImageDal.GetAll().Where(c => c.CarId == carId).Count();

            if (result >= 5)
            {
                return new ErrorResult(Messages.MaxImageCountExceed);
            }
            return new SuccessResult();
        }

        
    }
}
