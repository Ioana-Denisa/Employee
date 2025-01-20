namespace Client.ApplicationStates
{
    public class AllState
    {
        public Action? Action { get; set; }
        public bool ShowDivision { get; set; }
        public void DivisionClicked()
        {
            ResetAllDepartments();
            ShowDivision = true;
            Action?.Invoke();
        }

        public bool ShowDepartment { get; set; }
        public void DepartmentClicked()
        {
            ResetAllDepartments();
            ShowDepartment = true;
            Action?.Invoke();
        }

        public bool ShowSpecialization { get; set; }
        public void SpecializationClicked()
        {
            ResetAllDepartments();
            ShowSpecialization = true;
            Action?.Invoke();
        }

        public bool ShowCountry { get; set; }
        public void CountryClicked()
        {
            ResetAllDepartments();
            ShowCountry = true;
            Action?.Invoke();
        }

        public bool ShowCounty { get; set; }
        public void CountyClicked()
        {
            ResetAllDepartments();
            ShowCounty = true;
            Action?.Invoke();
        }

        public bool ShowTown { get; set; }
        public void TownClicked()
        {
            ResetAllDepartments();
            ShowTown = true;
            Action?.Invoke();
        }

        public bool ShowUser { get; set; }
        public void UserClicked()
        {
            ResetAllDepartments();
            ShowUser = true;
            Action?.Invoke();
        }

        public bool ShowEmployee { get; set; }
        public void EmployeeClicked()
        {
            ResetAllDepartments();
            ShowEmployee = true;
            Action?.Invoke();
        }

        private void ResetAllDepartments()
        {
            ShowDivision = false;
            ShowDepartment = false;
            ShowSpecialization = false;
            ShowCountry = false;
            ShowCounty = false;
            ShowTown = false;
            ShowUser = false;
            ShowEmployee = false;
        }
    }
}
