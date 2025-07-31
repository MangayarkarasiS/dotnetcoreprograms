using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Entities
{
    // The class "Category" will be acting as the data model for the Category Table in the database. 
    public class Category
    {
        /*
	     * This class should have seven fields
	     * (categoryId,categoryName,categoryDescription,
	     * categoryCreatedBy,categoryCreationDate,notes,user). Out of these six fields, the
	     * field categoryId should be primary key and auto-generated. The value of
	     * categoryCreationDate should not be accepted from the user but should be
	     * always initialized with the system date. annotate notes and user field with [JsonIgnore]
	 */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryCreatedBy { get; set; }
        public DateTime CategoryCreationDate { get; set; }
        [JsonIgnore]
        public Note Notes { get; set; }
        [JsonIgnore]
        public User Users { get; set; }
        public string CreatedBy { get; set; }
    }
}
