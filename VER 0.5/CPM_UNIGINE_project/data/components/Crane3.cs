using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Unigine;

#if UNIGINE_DOUBLE
using Vec3 = Unigine.dvec3;
using Vec4 = Unigine.dvec4;
using Mat4 = Unigine.dmat4;
#else
    using Vec3 = Unigine.vec3;
    using Vec4 = Unigine.vec4;
    using Mat4 = Unigine.mat4;
#endif

[Component(PropertyGuid = "8f8f9cd00f84c9efa6f96e82e3d35bf90020d504")]
public class eqp_check3 : DbContext
{
    public DbSet<qptomov3> table_equipment { get; set; }
    public eqp_check3()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=13092001");
    }
}

public class qptomov3
{

    public int id { get; set; }
    public int sst { get; set; }
	public string name { get; set; }
    public string model { get; set; }
    public TimeSpan working_time { get; set; }

}


public class Crane3 : Component
{
	
	public float time = 0;
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
		time += Game.IFps;//timer
		// write here code to be called before updating each render frame
		if (time > 15)
		{
			using (eqp_check3 db = new eqp_check3())
            {
                
                var strf = db.table_equipment.ToList();

                foreach (qptomov3 u in strf)
                {
                    if (u.id == 1260)
					{
						if (u.sst > 55){
							node.Position = new vec3(55, -7.57477, 13.17970);
                        	time = 0;
						} else {
							node.Position = new vec3(u.sst, -7.57477, 13.17970);
                        	time = 0;
						}
					}
                    
                }
            }


		}
	}
}