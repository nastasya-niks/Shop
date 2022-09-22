using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Введите имя")]
        [StringLength(5)]
        [Required(ErrorMessage ="Длина имени не менее 5 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(5)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string Surname { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина адреса не менее 15 символов")]
        public string Adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не менее 10 символов")]
        public string Phone { get; set; }

        [Display(Name = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина электронной почты не менее 15 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
