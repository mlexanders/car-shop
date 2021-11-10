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
        public string Name { get; set; }

        [Display(Name = "Введите Фамилию")]
        public string LastName { get; set; }

        [Display(Name = "Введите Адрес")]
        public string Adres { get; set; }

        [Display(Name = "Введите Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Введите Почту")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime{ get; set; }
        public List<OrderDatail> OrderDatails{ get; set; }
    }
}
