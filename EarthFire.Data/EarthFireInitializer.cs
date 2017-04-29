using System;
using System.Data.Entity;

namespace EarthFire.Data
{
  public class EarthFireInitializer : IDatabaseInitializer<EarthFireContext>
  {
    public void InitializeDatabase(EarthFireContext context)
    {
      // TODO: Add seed data
    }
  }
}