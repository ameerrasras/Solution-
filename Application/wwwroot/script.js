document.addEventListener("DOMContentLoaded", function () {
    const getAllDepartmentsButton = document.getElementById("getAllDepartmentsButton");
    const getDepartmentByIdButton = document.getElementById("getDepartmentByIdButton");
    const departmentIdInput = document.getElementById("departmentIdInput"); 
    const tableBody = document.querySelector("#departmentTable tbody");
    const createDepartmentButton = document.getElementById("createDepartmentButton");
    const newDepartmentNameInput = document.getElementById("newDepartmentName");
    const newDepartmentDescriptionInput = document.getElementById("newDepartmentDescription");
    const updateDepartmentButton = document.getElementById("updateDepartmentButton"); 

    function populateTable(departments) {
        tableBody.innerHTML = '';

        if (Array.isArray(departments)) {
            departments.forEach(department => {
                const row = tableBody.insertRow();
                const cell1 = row.insertCell(0);
                const cell2 = row.insertCell(1);
                const cell3 = row.insertCell(2);
                const cell4 = row.insertCell(3);
                const cell5 = row.insertCell(4);
                const cell6 = row.insertCell(5);
                const cell7 = row.insertCell(6);
                const cell8 = row.insertCell(7);
                const cell9 = row.insertCell(8);

                cell1.textContent = department.id;
                cell2.textContent = department.name;
                cell3.textContent = department.description;
                cell4.textContent = department.createdBy || "N/A";
                cell5.textContent = department.createdOn || "N/A";
                cell6.textContent = department.modifiedBy || "N/A";
                cell7.textContent = department.modifiedOn || "N/A";

                const deleteButton = document.createElement("button");
                deleteButton.textContent = "Delete";
                deleteButton.classList.add("delete-button");
                deleteButton.setAttribute("data-department-id", department.id);
                cell9.appendChild(deleteButton);
            });
        } else {
            const row = tableBody.insertRow();
            const cell1 = row.insertCell(0);
            const cell2 = row.insertCell(1);
            const cell3 = row.insertCell(2);
            const cell4 = row.insertCell(3);
            const cell5 = row.insertCell(4);
            const cell6 = row.insertCell(5);
            const cell7 = row.insertCell(6);

            cell1.textContent = departments.id;
            cell2.textContent = departments.name;
            cell3.textContent = departments.description;
            cell4.textContent = departments.createdBy || "N/A";
            cell5.textContent = departments.createdOn || "N/A";
            cell6.textContent = departments.modifiedBy || "N/A";
            cell7.textContent = departments.modifiedOn || "N/A";
        }
    }

    tableBody.addEventListener("click", function (event) {
        if (event.target.classList.contains("delete-button")) {
            const departmentIdToDelete = event.target.getAttribute("data-department-id");

            fetch(`http://localhost:5108/api/Departments/${departmentIdToDelete}`, {
                method: 'DELETE'
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    alert(data.message);
                })
                .catch(error => console.error('Error deleting department:', error));
        }
    });

    getAllDepartmentsButton.addEventListener("click", function () {
        fetch('http://localhost:5108/api/Departments')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                populateTable(data);
            })
            .catch(error => console.error('Error fetching data:', error));
    });

    getDepartmentByIdButton.addEventListener("click", function () {
        const departmentId = departmentIdInput.value; 
        if (!departmentId) {
            alert("Please enter a department ID.");
            return;
        }

        fetch(`http://localhost:5108/api/Departments/${departmentId}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                if (data.length === 0) {
                    alert("No department found with the specified ID.");
                } else {
                    populateTable(data);
                }
            })
            .catch(error => console.error('Error fetching data:', error));
    });


    createDepartmentButton.addEventListener("click", function () {
        const newDepartment = {
            name: newDepartmentNameInput.value,
            description: newDepartmentDescriptionInput.value,
        };

        if (!newDepartment.name) {
            alert("Please enter a department name.");
            return;
        }

        fetch('http://localhost:5108/api/Departments', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newDepartment)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                alert(`New department created with ID: ${data.id}`);
            })
            .catch(error => console.error('Error creating department:', error));
    });

    updateDepartmentButton.addEventListener("click", function () {
        const departmentIdToUpdate = departmentIdInput2.value; 

        if (!departmentIdToUpdate) {
            alert("Please enter a department ID.");
            return;
        }

        const updatedDepartment = {
            id: departmentIdToUpdate,
            name: newDepartmentNameInput.value,
            description: newDepartmentDescriptionInput.value,
        };

        fetch(`http://localhost:5108/api/Departments/${departmentIdToUpdate}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedDepartment)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                alert(`Department updated with ID: ${data.id}, Name: ${data.name}, Description: ${data.description}`);
            })
            .catch(error => console.error('Error updating department:', error));
    });


    const deleteDepartmentButton = document.getElementById("deleteDepartmentButton");

    deleteDepartmentButton.addEventListener("click", function () {
        const departmentIdToDelete = departmentIdInput2.value;

        if (!departmentIdToUpdate) {
            alert("Please enter a department ID.");
            return;
        }

        fetch(`http://localhost:5108/api/Departments/${departmentIdToUpdate}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                alert(data.message);
            })
            .catch(error => console.error('Error deleting department:', error));
    });
});
