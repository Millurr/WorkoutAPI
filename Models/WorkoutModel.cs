
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutAPI.Models;

public class WorkoutModel : CategoryModel
{
    public int WorkoutId { get; set; }
    
    public string Name { get; set; } = "Example Name";

    public int Complexity { get; set; } = 1;
}

public class CategoryModel
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

}