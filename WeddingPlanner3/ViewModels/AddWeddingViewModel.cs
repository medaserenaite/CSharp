using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner3.ViewModels {
    public class AddWeddingViewModel {

        [Required(ErrorMessage = "Required Field")]
        public string WedderOne { get; set; }


        [Required(ErrorMessage = "Required Field")]
        public string WedderTwo { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

    }
}