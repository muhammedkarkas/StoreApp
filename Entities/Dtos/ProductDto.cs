﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto //veri transfer nesnesi
    {
        public int ProductId { get; init; }

        [Required(ErrorMessage = "ProductName is required.")]
        public string? ProductName { get; init; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; init; }
        public string? Summary { get; init; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }

        //init initialize aşamasında değeri verilecek şekilde ayarlanmaktadır.
        //İmageUrl alanında set alanı init yapılmayacaktır.Önce dosya yüklenecek dosya yüklendikten sonra dosyanın fiziksel yolu belli olacak.Atama işlemi daha sonra yapılacaktır.
    }
}
