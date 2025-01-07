const baseUrl = '/api/Cars';
let cars = [];

// Получить все автомобили
async function getCars() {
    try {
        const response = await fetch(baseUrl);
        if (!response.ok) throw new Error('Ошибка получения данных');
        cars = await response.json();
        renderCars(cars);
    } catch (error) {
        console.error(error);
    }
}

// Добавить автомобиль
async function createCar(car) {
    try {
        console.log(JSON.stringify(car));

        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(car),
        });
        console.log(response.status);  // Статус ответа
        console.log(response.statusText);  // Текст ответа
        if (!response.ok) throw new Error('Ошибка создания автомобиля');
        await getCars(); // Обновляем список автомобилей
    } catch (error) {
        console.error(error);
    }
}

// Обновить автомобиль
async function updateCar(car) {
    try {
        console.log(JSON.stringify(car));

        const response = await fetch(`${baseUrl}/${car.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(car),
        });
        if (!response.ok) throw new Error('Ошибка обновления автомобиля');
        await getCars();
    } catch (error) {
        console.error(error);
    }
}

// Удалить автомобиль
async function deleteCar(id) {
    try {
        const response = await fetch(`${baseUrl}/${id}`, { method: 'DELETE' });
        if (!response.ok) throw new Error('Ошибка удаления автомобиля');
        await getCars();
    } catch (error) {
        console.error(error);
    }
}

// Отобразить автомобили на странице
function renderCars(cars) {
    const tableBody = document.getElementById('carsTableBody');
    tableBody.innerHTML = ''; // Очистить предыдущие данные

    cars.forEach(car => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${car.id}</td>
            <td>${car.brand}</td>
            <td>${car.number}</td>
            <td>${car.client.surname} ${car.client.name} ${car.client.middleName}</td>
            <td>
                <button onclick="showUpdateForm(${car.id})">Редактировать</button>
                <button onclick="deleteCar(${car.id})">Удалить</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}