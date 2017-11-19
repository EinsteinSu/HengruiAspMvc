using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Hengrui.DataAccess.Models.Organization;

namespace Hengrui.Business
{
    public interface ICityMgr : ICrudMgr<City>
    {
        IEnumerable<Region> GetRegions(int cityId);

        void AddRegion(int cityId, Region region);

        void UpdateRegion(Region region);

        void DeleteRegion(int regionId);
    }

    public class CityMgr : CrudMgrBase<City>, ICityMgr
    {
        protected override string EntityName => "City";

        protected override IEnumerable<City> GetEntries()
        {
            return Context.Cities.ToList();
        }

        protected override City GetEntry(int id)
        {
            return Context.Cities.FirstOrDefault(f => f.Id == id);
        }

        protected override void AddItem(City item)
        {
            Context.Cities.Add(item);
        }

        protected override void DeleteItem(City item)
        {
            Context.Cities.Remove(item);
        }

        public IEnumerable<Region> GetRegions(int cityId)
        {
            return Context.Regions.Where(w => w.CityId == cityId).ToList();
        }

        public void AddRegion(int cityId, Region region)
        {
            region.CityId = cityId;
            try
            {
                Context.Regions.Add(region);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Add Region failed, {e.Message}");
            }

        }

        public void UpdateRegion(Region region)
        {
            try
            {
                Context.Entry(region).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Add Region failed, {e.Message}");
            }
        }

        public void DeleteRegion(int regionId)
        {
            try
            {
                var item = Context.Regions.FirstOrDefault(f => f.Id == regionId);
                if (item == null)
                    throw new KeyNotFoundException($"Could not found id {regionId} in Regions.");
                Context.Regions.Remove(item);
                Context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception($"delete region failed, {exception.Message}");
            }
        }
    }
}