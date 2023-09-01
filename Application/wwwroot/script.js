fetch('https://localhost:7128/api/Departments')
    .then(response => response.json())
    .then(data => {
        const tableBody = document.querySelector("#departmentTable tbody");

        data.forEach(department => {
            const row = tableBody.insertRow();
            const cell1 = row.insertCell(0);
            const cell2 = row.insertCell(1);
            const cell3 = row.insertCell(2);
            const cell4 = row.insertCell(3);
            const cell5 = row.insertCell(4);
            const cell6 = row.insertCell(5);
            const cell7 = row.insertCell(6);
            const cell8 = row.insertCell(7);

            cell1.innerHTML = department.id;
            cell2.innerHTML = department.name;
            cell3.innerHTML = department.description;
            cell4.innerHTML = department.createdBy || "N/A";
            cell5.innerHTML = department.createdOn || "N/A";
            cell6.innerHTML = department.modifiedBy || "N/A";
            cell7.innerHTML = department.modifiedOn || "N/A";
            cell8.innerHTML = department.isDeleted;
        });
    })
    .catch(error => console.error('Error fetching data:', error));
