using System.ComponentModel.DataAnnotations;

namespace eDoc.Data.Models
{
    public enum TypeOfCheckup
    {
        Амбулаторен = 1, 
        Домашен =2,
        [Display(Name = "Инцидентно посещение")]
        Инцидентно_посещение = 3
    }
}