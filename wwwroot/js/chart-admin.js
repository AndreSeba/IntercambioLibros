window.inicializarGraficos = (estados, generos, actividad) => {
    // Gráfico de estados de validación (doughnut)
    new Chart(document.getElementById('graficoEstados'), {
        type: 'doughnut',
        data: {
            labels: Object.keys(estados),
            datasets: [{
                label: 'Estados de validación',
                data: Object.values(estados),
                backgroundColor: ['#4caf50', '#ff9800', '#f44336'],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { position: 'bottom' },
                title: { display: true, text: 'Estados de Validación' }
            }
        }
    });

    // Gráfico de géneros más populares (bar)
    new Chart(document.getElementById('graficoGeneros'), {
        type: 'bar',
        data: {
            labels: Object.keys(generos),
            datasets: [{
                label: 'Libros por Género',
                data: Object.values(generos),
                backgroundColor: '#2196f3'
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: false },
                title: { display: true, text: 'Géneros Más Populares' }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });

    // Gráfico de actividad diaria (line)
    new Chart(document.getElementById('graficoActividad'), {
        type: 'line',
        data: {
            labels: actividad.map(x => x.Fecha),
            datasets: [{
                label: 'Libros Publicados por Día',
                data: actividad.map(x => x.Cantidad),
                borderColor: '#9c27b0',
                backgroundColor: '#e1bee7',
                tension: 0.3,
                fill: true
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: { display: true, text: 'Actividad Diaria de Publicación' }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
};
