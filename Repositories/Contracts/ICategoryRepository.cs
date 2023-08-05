using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        //Tekrardan metot tanımlaması yapmaya gerek yok basedeki metot tanımlamaları üzerinden işlemler yerine getirilebilir.
    }
}
