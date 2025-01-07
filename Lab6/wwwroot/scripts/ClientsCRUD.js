const baseUrl = '/api/Clients';
let clients = []

// Получить всех клиентов
async function getClients() {
    try {
        const response = await fetch(baseUrl);
        if (!response.ok) throw new Error('Ошибка получения данных');
        clients = await response.json();
        renderClients(clients);
    } catch (error) {
        console.error(error);
    }
}

// Добавить клиента
async function createClient(client) {
    try {
        client.isRegularClient = (client.isRegularClient === "true");
        console.log(JSON.stringify(client))

        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(client),
        });
        console.log(response.status);  // Статус ответа
        console.log(response.statusText);  // Текст ответа
        if (!response.ok) throw new Error('Ошибка создания клиента');
        await getClients(); // Обновляем список клиентов
    } catch (error) {
        console.error(error);
    }
}

// Обновить клиента
async function updateClient(client) {
    try {
        client.isRegularClient = (client.isRegularClient === "true");

        console.log(JSON.stringify(client));

        const response = await fetch(`${baseUrl}/${client.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(client),
        });
        if (!response.ok) throw new Error('Ошибка обновления клиента');
        await getClients();
    } catch (error) {
        console.error(error);
    }
}

// Удалить клиента
async function deleteClient(id) {
    try {
        const response = await fetch(`${baseUrl}/${id}`, { method: 'DELETE' });
        if (!response.ok) throw new Error('Ошибка удаления клиента');
        await getClients();
    } catch (error) {
        console.error(error);
    }
}

// Отобразить клиентов на странице
function renderClients(clients) {
    const tableBody = document.getElementById('clientsTableBody');
    tableBody.innerHTML = ''; // Очистить предыдущие данные

    clients.forEach(client => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${client.id}</td>
            <td>${client.name}</td>
            <td>${client.middleName}</td>
            <td>${client.surname}</td>
            <td>${client.telephone}</td>
            <td>${client.isRegularClient ? 'Да' : 'Нет'}</td>
            <td>
                <button onclick="showUpdateForm(${client.id})">Редактировать</button>
                <button onclick="deleteClient(${client.id})">Удалить</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

