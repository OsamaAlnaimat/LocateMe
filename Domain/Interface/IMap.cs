using Domain.Entity;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
	public interface  IMap
	{

		//CRUD Op	
		OpStatus Add(Map map);
		OpStatus Update(Map map);
		OpStatus Delete(Guid id);	
		List<Map> List();
		Map GetById(Guid id);
	}
}
