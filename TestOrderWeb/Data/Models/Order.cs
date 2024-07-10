using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOrderWebApplication.Data.Models
{
    public class Order
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Введите город отправителя")]
        [StringLength(30)]
        [Required(ErrorMessage ="Название города должен быть не более 30 символов")]
        public string SenderCity { get; set; }

        [Display(Name = "Введите адрес отправителя")]
        [StringLength(40)]
        [Required(ErrorMessage = "Адрес должен быть не более 40 символов")]
        public string SenderAddres { get; set; }

        [Display(Name = "Введите город получателя")]
        [StringLength(30)]
        [Required(ErrorMessage = "Название города должен быть не более 30 символов")]
        public string RecipientCity { get; set; }

        [Display(Name = "Введите адрес получателя")]
        [StringLength(40)]
        [Required(ErrorMessage = "Адрес должен быть не более 40 символов")]
        public string RecipientAddres { get; set; }

        [Display(Name = "Введите вес заказа")]
        [StringLength(5)]
        [Required(ErrorMessage = "Вес должен быть менее 100000")]
        public string CargoWeight { get; set; }


        [DataType(DataType.Date)]
        public string DateCargoPickup { get; set; }

    }
}
