window.renderChart = (chartId, labels, data, chartType = "bar") => {
    console.log("Запуск renderChart:", chartId, labels, data, chartType);
    const ctx = document.getElementById(chartId);
    if (!ctx) {
        console.error("Элемент canvas с id " + chartId + " не найден.");
        return;
    }
    console.log("Canvas найден, инициализация Chart.js...");
    try {
        new Chart(ctx.getContext('2d'), {
            type: chartType, 
            data: {
                labels: labels,
                datasets: [{
                    label: chartType === "bar" ? 'Бронирования' : chartType === "pie" ? 'Статусы' : 'Тренд',
                    data: data,
                    backgroundColor: chartType === "bar" ? '#4CAF50' : chartType === "pie" ? ['#4CAF50', '#FF9800', '#F44336'] : 'rgba(54, 162, 235, 0.2)',
                    borderColor: chartType === "bar" ? '#45A049' : chartType === "pie" ? ['#45A049', '#F57C00', '#D32F2F'] : 'rgba(54, 162, 235, 1)',
                    borderWidth: chartType === "line" ? 2 : 1,
                    fill: chartType === "line" ? false : true
                }]
            },
            options: {
                scales: chartType === "bar" || chartType === "line" ? {
                    y: {
                        beginAtZero: true
                    }
                } : {}
            }
        });
        console.log("Диаграмма успешно создана.");
    } catch (error) {
        console.error("Ошибка при создании диаграммы:", error);
    }
};