using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
	public enum OpStatus
	{
		None = 0,
		Success = 1,
		Error = 2,
		UserNotFound = 3,
		UserAlreadyExists = 4
	}
}
