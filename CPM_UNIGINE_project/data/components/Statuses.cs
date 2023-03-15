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

[Component(PropertyGuid = "fabd304e10e77b555ea114b03e0b204ff9961162")]
public class workers_check : DbContext
{
    public DbSet<Worker> table_workers { get; set; }
    public workers_check()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=13092001");
    }
}

public class Worker
{

    public int id { get; set; }
    public string name { get; set; }
    public int sst { get; set; }

}


public class Statuses : Component
{
	
        public int sos1 = 0;
        public int sos2 = 0;
        public int sos3 = 0;
        public int sos4 = 0;
        public int sos5 = 0;
        public int sos6 = 0;
        public int sos7 = 0;
        public int sos8 = 0;
        public int sos9 = 0;

    public float time = 0;

        public Node rd1;
        public Node gr1;
        public Node bl1;

        public Node rd2;
        public Node gr2;
        public Node bl2;

        public Node rd3;
        public Node gr3;
        public Node bl3;

        public Node rd4;
        public Node gr4;
        public Node bl4;

        public Node rd5;
        public Node gr5;
        public Node bl5;

        public Node rd6;
        public Node gr6;
        public Node bl6;

        public Node rd7;
        public Node gr7;
        public Node bl7;

        public Node rd8;
        public Node gr8;
        public Node bl8;

        public Node rd9;
        public Node gr9;
        public Node bl9;

        public dvec3 locrd1;
        public dvec3 locgr1;
        public dvec3 locbl1;

        public dvec3 locrd2;
        public dvec3 locgr2;
        public dvec3 locbl2;

        public dvec3 locrd3;
        public dvec3 locgr3;
        public dvec3 locbl3;

        public dvec3 locrd4;
        public dvec3 locgr4;
        public dvec3 locbl4;

        public dvec3 locrd5;
        public dvec3 locgr5;
        public dvec3 locbl5;

        public dvec3 locrd6;
        public dvec3 locgr6;
        public dvec3 locbl6;

        public dvec3 locrd7;
        public dvec3 locgr7;
        public dvec3 locbl7;

        public dvec3 locrd8;
        public dvec3 locgr8;
        public dvec3 locbl8;

        public dvec3 locrd9;
        public dvec3 locgr9;
        public dvec3 locbl9;



    private void Init()
        {
            // write here code to be called on component initialization
            locrd1 = rd1.Position;
            locgr1 = gr1.Position;
            locbl1 = bl1.Position;

        locrd2 = rd2.Position;
        locgr2 = gr2.Position;
        locbl2 = bl2.Position;

        locrd3 = rd3.Position;
        locgr3 = gr3.Position;
        locbl3 = bl3.Position;

        locrd4 = rd4.Position;
        locgr4 = gr4.Position;
        locbl4 = bl4.Position;

        locrd5 = rd5.Position;
        locgr5 = gr5.Position;
        locbl5 = bl5.Position;

        locrd6 = rd6.Position;
        locgr6 = gr6.Position;
        locbl6 = bl6.Position;

        locrd7 = rd7.Position;
        locgr7 = gr7.Position;
        locbl7 = bl7.Position;

        locrd8 = rd8.Position;
        locgr8 = gr8.Position;
        locbl8 = bl8.Position;

        locrd9 = rd9.Position;
        locgr9 = gr9.Position;
        locbl9 = bl9.Position;



    }

        private void Update()
        {
        // write here code to be called before updating each render frame

        time += Game.IFps;

        
        if (time > 15)
        {
            using (workers_check db = new workers_check())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.table_workers.ToList();

                foreach (Worker u in users)
                {

                    if (u.id == 1001)
                    {
                        sos1 = u.sst;
                    }else if (u.id == 1002)
                    {
                        sos2 = u.sst;
                    }else if (u.id == 1003)
                    {
                        sos3 = u.sst;
                    }else if (u.id == 1004)
                    {
                        sos4 = u.sst;
                    }else if (u.id == 1005)
                    {
                        sos5 = u.sst;
                    }else if (u.id == 1006)
                    {
                        sos6 = u.sst;
                    }else if(u.id == 1007)
                    {
                        sos7 = u.sst;
                    }else if (u.id == 1008)
                    {
                        sos8 = u.sst;
                        
                    }else if (u.id == 1009)
                    {
                        sos9 = u.sst;

                    }
                }
            }
            
            time = 0;
        }

        if (sos1 == 1)
        {

            bl1.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr1.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd1.Position = locrd1;
        }else if (sos1 == 2)
        {
            rd1.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr1.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl1.Position = locbl1;
        }
        else if (sos1 == 3)
        {
            rd1.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl1.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr1.Position = locgr1;
        }

        if (sos2 == 1)
        {

            bl2.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr2.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd2.Position = locrd2;
        }
        else if (sos2 == 2)
        {
            rd2.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr2.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl2.Position = locbl2;
        }
        else if (sos2 == 3)
        {
            rd2.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl2.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr2.Position = locgr2;
        }

        if (sos3 == 1)
        {

            bl3.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr3.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd3.Position = locrd3;
        }
        else if (sos3 == 2)
        {
            rd3.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr3.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl3.Position = locbl3;
        }
        else if (sos3 == 3)
        {
            rd3.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl3.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr3.Position = locgr3;
        }

        if (sos4 == 1)
        {

            bl4.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr4.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd4.Position = locrd4;
        }
        else if (sos4 == 2)
        {
            rd4.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr4.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl4.Position = locbl4;
        }
        else if (sos4 == 3)
        {
            rd4.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl4.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr4.Position = locgr4;
        }

        if (sos5 == 1)
        {

            bl5.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr5.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd5.Position = locrd5;
        }
        else if (sos5== 2)
        {
            rd5.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr5.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl5.Position = locbl5;
        }
        else if (sos5 == 3)
        {
            rd5.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl5.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr5.Position = locgr5;
        }
        
        if (sos6 == 1)
        {

            bl6.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr6.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd6.Position = locrd6;
        }
        else if (sos6 == 2)
        {
            rd6.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr6.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl6.Position = locbl6;
        }
        else if (sos6 == 3)
        {
            rd6.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl6.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr6.Position = locgr6;
        }

        if (sos7 == 1)
        {

            bl7.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr7.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd7.Position = locrd7;
        }
        else if (sos7 == 2)
        {
            rd7.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr7.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl7.Position = locbl7;
        }
        else if (sos7 == 3)
        {
            rd7.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl7.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr7.Position = locgr7;
        }

        if (sos8 == 1)
        {

            bl8.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr8.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd8.Position = locrd8;
        }
        else if (sos8 == 2)
        {
            rd8.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr8.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl8.Position = locbl8;
        }
        else if (sos8 == 3)
        {
            rd8.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl8.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr8.Position = locgr8;
        }

        if (sos9 == 1)
        {

            bl9.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr9.Position = new Vec3(0.0f, 0.0f, -100.0f);
            rd9.Position = locrd9;
        }
        else if (sos9 == 2)
        {
            rd9.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr9.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl9.Position = locbl9;
        }
        else if (sos9 == 3)
        {
            rd9.Position = new Vec3(0.0f, 0.0f, -100.0f);
            bl9.Position = new Vec3(0.0f, 0.0f, -100.0f);
            gr9.Position = locgr9;
        }
        
    }
}