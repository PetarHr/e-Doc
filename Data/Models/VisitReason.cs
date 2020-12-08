using System.ComponentModel.DataAnnotations;

namespace eDoc.Data.Models
{
    public enum VisitReason
    {
        [Display(Name = "Консултация")]
        Консултация = 1,
        [Display(Name = "Профилактика")]
        Профилактика = 2,
        [Display(Name = "Диспансерен преглед")]
        Диспансерен_преглед = 3,
        [Display(Name = "ВСД")]
        ВСД = 4,
        [Display(Name = "Рецепта на хоспитализирано ЗОЛ")]
        Рецепта_на_хоспитализирано_ЗОЛ = 5,
        [Display(Name = "Експертиза на работоспособността")]
        Експертиза_на_работоспособността = 6,
        [Display(Name = "По искане на ТЕЛК")]
        По_искане_на_ТЕЛК = 7,
        [Display(Name = "Имунизация")]
        Имунизация = 8
    }
}