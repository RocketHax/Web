﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthFire.Model.Entities
{
  public class EvacuationPoint : IEntityBase
  {
    public int Id { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }
  }
}
