using ReefTankCore.Web.Areas.Admin.Models.Creatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Web.Areas.Admin.Models.Subcategories
{
    public class SubcategoryFormModel
    {
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public string Description { get; set; }

        public string CategorySlug { get; set; }

        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public Guid CategoryId { get; set; }

        public List<Category> CategoryItems { get; set; }
    }
}