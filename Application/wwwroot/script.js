document.addEventListener("DOMContentLoaded", function () {
    const getAllDepartmentsButton = document.getElementById("getAllDepartmentsButton");
    const getDepartmentByIdButton = document.getElementById("getDepartmentByIdButton");
    const departmentIdInput = document.getElementById("departmentIdInput"); // Corrected ID
    const tableBody = document.querySelector("#departmentTable tbody");
    const createDepartmentButton = document.getElementById("createDepartmentButton");
    const newDepartmentNameInput = document.getElementById("newDepartmentName");
    const newDepartmentDescriptionInput = document.getElementById("newDepartmentDescription");
    const updateDepartmentButton = document.getElementById("updateDepartmentButton"); // Added

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

                // Create and add a "Delete" button with a data-attribute for department ID
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

    // Event listener for "Delete Department" buttons
    tableBody.addEventListener("click", function (event) {
        if (event.target.classList.contains("delete-button")) {
            const departmentIdToDelete = event.target.getAttribute("data-department-id");

            // Send a DELETE request to delete the department
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
                    // Assuming the API returns a success message
                    alert(data.message);
                    // You can optionally update the table or refresh data
                })
                .catch(error => console.error('Error deleting department:', error));
        }
    });

    // Event listener for "Get All Departments" button
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
        const departmentId = departmentIdInput.value; // Corrected variable name

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

        // Validate required fields (e.g., name)
        if (!newDepartment.name) {
            alert("Please enter a department name.");
            return;
        }

        // Send a POST request to create a new department
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
                // Assuming the API returns the newly created department object
                alert(`New department created with ID: ${data.id}`);
                // You can optionally clear the input fields or update the table
            })
            .catch(error => console.error('Error creating department:', error));
    });
    // Assuming you have a "Delete" button with the id "deleteDepartmentButton"

    updateDepartmentButton.addEventListener("click", function () {
        const departmentIdToUpdate = departmentIdInput2.value; // Corrected variable name

        if (!departmentIdToUpdate) {
            alert("Please enter a department ID.");
            return;
        }

        const updatedDepartment = {
            id: departmentIdToUpdate, // Include the department ID in the request body
            name: newDepartmentNameInput.value,
            description: newDepartmentDescriptionInput.value,
        };

        // Send a PUT request to update the department
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
                // Assuming the API returns the updated department object
                alert(`Department updated with ID: ${data.id}, Name: ${data.name}, Description: ${data.description}`);
                // You can optionally clear the input fields or update the table
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

        // Send a DELETE request to delete the department
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
                // Assuming the API returns a success message
                alert(data.message);
                // You can optionally update the table or refresh data
            })
            .catch(error => console.error('Error deleting department:', error));
    });
});
