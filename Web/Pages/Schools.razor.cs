using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages
{
    public partial class Schools
    {
        // Bindable variables
        private IEnumerable<School> SchoolList = new List<School>();

        // Show loading spinner when true
        private bool Loading;

        // Error information
        private string ErrorMessage;
        private bool showError;

        /// <summary>
        /// When the page loads, fetch all the schools
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Loading = true;

                var data = await SchoolRepository.GetAll().ConfigureAwait(false);
                SchoolList = data.ToList();
                
                Loading = false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                showError = true;
            }
        }
    }
}