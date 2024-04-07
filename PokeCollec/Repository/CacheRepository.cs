using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Repository;

public class CacheRepository
{
    public CacheRepository()
    {
        if(!Directory.Exists("cache"))
            Directory.CreateDirectory("cache");
    }
}
