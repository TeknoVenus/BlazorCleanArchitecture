using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages
{
    public partial class Students
    {
        [Inject]
        public ISchoolRepository SchoolRepository { get; set; }

        [Inject]
        public IStudentRepository StudentRepository { get; set; }

        // Bindable variables
        public List<School> SchoolList = new List<School>();
        public List<Student> StudentList = new List<Student>();

        // Show/hide loading spinner
        public bool Loading;

        // Error information
        public string ErrorMessage;
        public bool showError;

        // School selected in dropdown box
        private School _selectedSchool;
        private School SelectedSchool
        {
            get => _selectedSchool;
            set
            {
                // When the selected school changes, fire off the LoadStudents method
                _selectedSchool = value;
                InvokeAsync(LoadStudentsForSchool);
            }
        }

        /// <summary>
        /// When the page loads, get all the schools to choose form
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var schools = await SchoolRepository.GetAll();
                SchoolList = schools.ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                showError = true;
            }
        }

        /// <summary>
        /// Gets all the students for the selected school
        /// </summary>
        /// <returns></returns>
        private async Task LoadStudentsForSchool()
        {
            try
            {
                Loading = true;
                // TODO:: Understand more about Blazor state - https://docs.microsoft.com/en-us/aspnet/core/blazor/components?view=aspnetcore-3.1#invoke-component-methods-externally-to-update-state
                await InvokeAsync(StateHasChanged);

                var students = await StudentRepository.GetAll(_selectedSchool.Id).ConfigureAwait(false);
                StudentList = students.ToList();

                Loading = false;
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                showError = true;
            }
        }
    }
}