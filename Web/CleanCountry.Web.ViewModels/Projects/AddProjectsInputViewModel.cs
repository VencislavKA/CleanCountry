﻿namespace CleanCountry.Web.ViewModels.Projects
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class AddProjectsInputViewModel
    {
        [Required(ErrorMessage = "Заглавието е задължително поле")]
        [StringLength(30, ErrorMessage = "Заглавието трябва да е между 5 и 30 символа", MinimumLength = 5)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описанието е задължително поле")]
        [StringLength(500, ErrorMessage = "Заглавието трябва да е между 30 и 500 символа", MinimumLength = 30)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Снимката е задължителна" )]
        [Display(Name = "Изберете снимка за проекта")]
        public IFormFile Image { get; set; }
    }
}