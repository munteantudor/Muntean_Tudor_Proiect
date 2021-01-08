using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Muntean_Tudor_Proiect.Data;

namespace Muntean_Tudor_Proiect.Models
{
    public class VinylCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Muntean_Tudor_ProiectContext context,
        Vinyl vinyl)
        {
            var allCategories = context.Category;
            var vinylCategories = new HashSet<int>(
            vinyl.VinylCategories.Select(c => c.VinylID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = vinylCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateVinylCategories(Muntean_Tudor_ProiectContext context,
        string[] selectedCategories, Vinyl vinylToUpdate)
        {
            if (selectedCategories == null)
            {
                vinylToUpdate.VinylCategories = new List<VinylCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var vinylCategories = new HashSet<int>
            (vinylToUpdate.VinylCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!vinylCategories.Contains(cat.ID))
                    {
                        vinylToUpdate.VinylCategories.Add(
                        new VinylCategory
                        {
                            VinylID = vinylToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (vinylCategories.Contains(cat.ID))
                    {
                        VinylCategory courseToRemove
                        = vinylToUpdate
                        .VinylCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }

            }
        }
    }
}
