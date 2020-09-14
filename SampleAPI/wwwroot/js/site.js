const uri = 'api/message';
let messages = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .catch(error => console.error('Unable to get items.', error));
}

function displayAllItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function displayFirstItemMessage() {
    const itemId = '1';

    fetch(`${uri}/${itemId}`)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('messages');
    tBody.innerHTML = '';

    const button = document.createElement('button');
    if (Array.isArray(data)) {
        data.forEach(item => {
            let isCompleteCheckbox = document.createElement('input');
            isCompleteCheckbox.type = 'checkbox';
            isCompleteCheckbox.disabled = true;
            isCompleteCheckbox.checked = item.isComplete;

            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

            let tr = tBody.insertRow();

            let td2 = tr.insertCell(0);
            let textNode = document.createTextNode(item.message);
            td2.appendChild(textNode);
        });
    }
    else {
        let tr = tBody.insertRow();
        let td2 = tr.insertCell(0);
        let textNode = document.createTextNode(data.message);
        td2.appendChild(textNode);
    }

    messages = data;
}
