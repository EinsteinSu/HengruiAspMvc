using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hengrui.DataAccess;
using Hengrui.DataAccess.Models;
using Hengrui.DataAccess.Models.Organization;
using Hengrui.DataAccess.Models.Organization.Users;

namespace Hengrui.DataMigration
{
    class Program
    {
        static HengruiDataContext _context = new HengruiDataContext();
        static HrcDataContext _hrc = new HrcDataContext();
        static CommonDataContext _common = new CommonDataContext();
        static void Main(string[] args)
        {
            SyncArea();
            SyncEnterpriseUsers();
            SyncProficients();
            SyncWeichatNumber();
        }

        static void SyncWeichatNumber()
        {
            foreach (var extension in _common.UserExtensions)
            {
                var user = _context.EnterpriseUsers.FirstOrDefault(f => f.OriginalId.Equals(extension.UserId));
                if (user != null)
                {
                    user.Contact.WeiChat = extension.Weixin;
                    _context.Entry(user).Property(p => p.Contact.WeiChat).IsModified = true;
                }
                var proficient = _context.Proficients.FirstOrDefault(f => f.OriginalId.Equals(extension.UserId));
                if (proficient != null)
                {
                    proficient.Contact.WeiChat = extension.Weixin;
                    _context.Entry(proficient).Property(p => p.Contact.WeiChat).IsModified = true;
                }
            }
            _context.SaveChanges();
        }

        static void SyncProficients()
        {
            foreach (var oProficient in _common.Proficients)
            {
                if (!_context.Proficients.Any(a => a.OriginalId.Equals(oProficient.Guid)))
                {
                    var user = new Proficient
                    {
                        Name = oProficient.UserName,
                        Password = oProficient.Password,
                        BirthDate = oProficient.BirthDate,
                        Gender = oProficient.Sex == "男" ? Gender.Male : Gender.Female,
                        OriginalId = oProficient.Guid,
                        Szdw = oProficient.Szdw,
                        Zy = ZyConvert(oProficient.Zy),
                        Contact = new Contact
                        {
                            Phone = oProficient.Tel,
                            Mobile = oProficient.Mobile,
                            QQ = oProficient.QQ,
                            Email = oProficient.Email
                        }
                    };
                    Console.WriteLine($"User {oProficient.UserName} will be inserted");
                    _context.Proficients.Add(user);
                }
            }
            _context.SaveChanges();
        }


        static MajorType ZyConvert(string zy)
        {
            switch (zy)
            {
                case "建筑":
                    return MajorType.Jz;
                case "暖通":
                    return MajorType.Nt;
                case "给排水":
                    return MajorType.Gps;
                case "电气":
                    return MajorType.Dq;
                default:
                    return MajorType.Jz;
            }
        }

        static void SyncEnterpriseUsers()
        {
            foreach (var oUser in _common.EnterpriseUsers)
            {
                if (!_context.EnterpriseUsers.Any(a => a.OriginalId.Equals(oUser.Guid)))
                {
                    var user = new EnterpriseUser
                    {
                        Name = oUser.UserName,
                        Password = oUser.Password,
                        BirthDate = oUser.BirthDate,
                        Gender = oUser.Sex == "男" ? Gender.Male : Gender.Female,
                        OriginalId = oUser.Guid,
                        Contact = new Contact
                        {
                            Phone = oUser.Tel,
                            Mobile = oUser.Mobile,
                            QQ = oUser.QQ,
                            Email = oUser.Email
                        }
                    };
                    Console.WriteLine($"User {oUser.UserName} will be inserted.");
                    _context.EnterpriseUsers.Add(user);
                }
            }
            _context.SaveChanges();
        }

        static void SyncArea()
        {
            foreach (var hrcArea in _hrc.Areas.Where(w => w.PGuid.Equals("0")))
            {
                if (!_context.Cities.Any(a => a.Name.Equals(hrcArea.Name)))
                {
                    var city = new City
                    {
                        Name = hrcArea.Name,
                        Regions = new List<Region>()
                    };

                    foreach (var area in _hrc.Areas.Where(w => w.PGuid.Equals(hrcArea.Guid)))
                    {
                        var region = new Region { Name = area.Name };
                        city.Regions.Add(region);
                    }
                    _context.Cities.Add(city);
                }
            }
            _context.SaveChanges();
        }
    }
}
