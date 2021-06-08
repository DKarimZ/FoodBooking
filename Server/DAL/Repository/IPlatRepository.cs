﻿using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public interface IPlatRepository : IgenericRepository<Plat> , IpageableRepository<Plat> , ISortableRepository<Plat>
	{
		Task<IEnumerable<Plat>> GetAllThePlatsByTypePlat(int idtypePlat);
	}
}
