﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
	public class GenrateGuid
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		
	}
}
