const uri = "api/saintsplayers";
let saintsPlayers = [];
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error("Unable to get items.", error));
}

function _displayItems(data) {
    console.log(data)
    const tBody = document.getElementById('saintsTable');
    tBody.innerHTML = '';
    data.forEach(item => {
        let tr = tBody.insertRow();
        insertRow(item.name, 0, tBody, tr);
        insertRow(item.position, 1, tBody, tr);
        insertRow(item.country, 2, tBody, tr);
        insertRow(item.appearances, 3, tBody, tr);
        insertRow(item.goals, 4, tBody, tr);
    })
}

function insertRow(string, position, tBody, tr) {
    let td = tr.insertCell(position);
    let textNode = document.createTextNode(string);
    td.appendChild(textNode);
}