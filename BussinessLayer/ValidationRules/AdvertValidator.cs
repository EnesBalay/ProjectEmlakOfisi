﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class AdvertValidator:AbstractValidator<Advert>
    {
        public AdvertValidator()
        {
            RuleFor(x => x.AdvertName).NotEmpty().WithMessage("İlan adını doldurmanız gerekmektedir.");
            RuleFor(x => x.AdvertPrice).NotEmpty().WithMessage("İlan fiyatını doldurmanız gerekmektedir");
            RuleFor(x => x.AdvertDescription).NotEmpty().WithMessage("İlan açıklamayı doldurmanız gerekmektedir.");
            RuleFor(x => x.AdvertImage1).NotEmpty().WithMessage("İlana ait en az 1 görsel eklemeniz gerekmektedir.");
            RuleFor(x => x.AdvertSaleType).NotEmpty().WithMessage("Satış türünü seçmeniz gerekmektedir.");
            RuleFor(x => x.HousingAge).NotEmpty().WithMessage("Konutun yaşını girmeniz gerekmektedir.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori seçmeniz gerekmektedir.");
            RuleFor(x => x.HousingHallQuantity).NotEmpty().WithMessage("Salon sayısını girmeniz gerekmektedir.");
            RuleFor(x => x.HousingRoomQuantity).NotEmpty().WithMessage("Oda sayısını girmeniz gerekmektedir.");
            RuleFor(x => x.HousingSquareMeters).NotEmpty().WithMessage("Konut m²'sini girmeniz gerekmektedir.");
            RuleFor(x => x.AdvertName).MaximumLength(150).WithMessage("İlan adı en fazla 150 karakter olmalıdır.");
            RuleFor(x => x.AdvertName).MinimumLength(5).WithMessage("İlan adı en az 5 karakter olmalıdır.");
            RuleFor(x => x.AdvertDescription).MaximumLength(10000).WithMessage("İlan açıklaması en fazla 10.000 karakter olmalıdır.");
            RuleFor(x => x.AdvertDescription).MinimumLength(5).WithMessage("İlan açıklaması en az 5 karakter olmalıdır.");
        }
    }
}