using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name ="Введите Имя")]
        [MinLength(1)]
        [Required(ErrorMessage ="Заполните поле")]
        public string Name { get; set; }

        [Display(Name = "Введите Фамилию")]
        [MinLength(1)]
        [Required(ErrorMessage = "Заполните поле")]
        public string LastName { get; set; }

        [Display(Name = "Введите Адрес")]
        [MinLength(1)]
        [Required(ErrorMessage = "Заполните поле")]
        public string Adres { get; set; }

        [Display(Name = "Введите Телефон")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(9)]
        [Required(ErrorMessage = "Заполните поле")]
        public string Phone { get; set; }

        [Display(Name = "Введите Почту")]
        [DataType(DataType.EmailAddress)]
        [MinLength(4)]
        [Required(ErrorMessage = "Заполните поле")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime{ get; set; }
        public List<OrderDatail> OrderDatails{ get; set; }
    }
}
