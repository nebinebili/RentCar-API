using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IResult Add(IFormFile file, CarImageDto carImage);
        IResult Delete(CarImageUpdateDeleteDto carImage);
        IResult Update(IFormFile file, CarImageUpdateDeleteDto carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}
