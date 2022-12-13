using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagesValidator: AbstractValidator<CarImage>
    {
        public CarImagesValidator() 
        {
            //RuleFor(c => c.ImagePath).Null();
        }
    }
}
