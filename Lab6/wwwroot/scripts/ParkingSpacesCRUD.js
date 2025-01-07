const baseUrl = '/api/ParkingSpaces';
let parkingSpaces = [];

// Получить все парковочные места
async function getParkingSpaces() {
    try {
        const response = await fetch(baseUrl);
        if (!response.ok) throw new Error('Ошибка получения данных');
        parkingSpaces = await response.json();
        renderParkingSpaces(parkingSpaces);
    } catch (error) {
        console.error(error);
    }
}

// Добавить парковочное место
async function createParkingSpace(parkingSpace) {
    try {
        console.log(JSON.stringify(parkingSpace));

        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(parkingSpace),
        });
        console.log(response.status);  // Статус ответа
        console.log(response.statusText);  // Текст ответа
        if (!response.ok) throw new Error('Ошибка создания парковочного места');
        await getParkingSpaces(); // Обновляем список парковочных мест
    } catch (error) {
        console.error(error);
    }
}

// Обновить парковочное место
async function updateParkingSpace(parkingSpace) {
    try {
        console.log(JSON.stringify(parkingSpace));

        const response = await fetch(`${baseUrl}/${parkingSpace.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(parkingSpace),
        });
        if (!response.ok) throw new Error('Ошибка обновления парковочного места');
        await getParkingSpaces();
    } catch (error) {
        console.error(error);
    }
}

// Удалить парковочное место
async function deleteParkingSpace(id) {
    try {
        const response = await fetch(`${baseUrl}/${id}`, { method: 'DELETE' });
        if (!response.ok) throw new Error('Ошибка удаления парковочного места');
        await getParkingSpaces();
    } catch (error) {
        console.error(error);
    }
}

// Отобразить парковочные места на странице
function renderParkingSpaces(parkingSpaces) {
    const tableBody = document.getElementById('parkingSpacesTableBody');
    tableBody.innerHTML = ''; // Очистить предыдущие данные

    parkingSpaces.forEach(parkingSpace => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${parkingSpace.id}</td>
            <td>${parkingSpace.isPenalty ? 'Нет' : 'Да'}</td>
            <td>${parkingSpace.car ? `${parkingSpace.car.brand} (${parkingSpace.car.number})` : 'Не занято'}</td>
            <td>
                <button onclick="showUpdateForm(${parkingSpace.id})">Редактировать</button>
                <button onclick="deleteParkingSpace(${parkingSpace.id})">Удалить</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}