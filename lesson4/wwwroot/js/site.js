const uri = '/Taskk';
let Tasking = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');

    const item = {
        TaskkName: addNameTextbox.value.trim(),
        IsDo: false,
        Id:1
    };

    fetch((uri), {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = Tasking.find(item => item.id === id);
    console.log(item+'h');
    console.log(item.taskkName+"itemnamr");
    document.getElementById('edit-name').value = item.taskkName;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isGlutenFree').checked = item.isDo;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    console.log(itemId+"irtff");

    const item = {
        Id: itemId,
        IsDo: document.getElementById('edit-isGlutenFree').checked,
        TaskkName: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));
    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Task' : 'Task kinds';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('Tasks');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isGlutenFreeCheckbox = document.createElement('input');
        isGlutenFreeCheckbox.type = 'checkbox';
        isGlutenFreeCheckbox.disabled = true;
        isGlutenFreeCheckbox.checked = item.isDo;
        console.log(item);
        console.log(item.taskkName);
        console.log(item.id);
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();
        console.log("sxcvbnm");
        console.log(tr);
        let td1 = tr.insertCell(0);
        td1.appendChild(isGlutenFreeCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.taskkName);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    Tasking= data;
}