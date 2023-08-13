using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDtoForUpdate : ProductDto
    {
        //ProductDto içerisinde yer alan propertyler yeni dto içerisinde de yer alacaktır. 
    }
}
