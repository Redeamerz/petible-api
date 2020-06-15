using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
	public class Pet_has_pettypeRepository : Repository<Quirk, string>, IQuirkRepository
    {
        public Pet_has_pettypeRepository(IUnitOfWork uow) : base(uow)
		{

		}
	}
}
