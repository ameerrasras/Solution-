document.addEventListener('DOMContentLoaded', function () {
    fetch('http://localhost:5001/api/Departments')
        .then(response => response.json())
        .then(data => createTable(data))
        .catch(error => console.log('Error:', error));
});

function createTable(data) {
    const table = document.createElement('table');
    const thead = document.createElement('thead');
    const tbody = document.createElement('tbody');


    const headers = ['ID', 'Name', 'Description', 'Created By', 'Created On', 'Modified By', 'Modified On', 'Is Deleted'];
    const headerRow = document.createElement('tr');
    headers.forEach(headerText => {
        const header = document.createElement('th');
        header.textContent = headerText;
        headerRow.appendChild(header);
    });
    thead.appendChild(headerRow);

    data.forEach(rowData => {
        const row = document.createElement('tr');
        headers.forEach(headerText => {
            const cell = document.createElement('td');
            cell.textContent = rowData[headerText.replace(/\s+/g, '').toLowerCase()] ?? '-';
            row.appendChild(cell);
        });
        tbody.appendChild(row);
    });

    table.appendChild(thead);
    table.appendChild(tbody);

    document.querySelector('#tableContainer').appendChild(table);
}
