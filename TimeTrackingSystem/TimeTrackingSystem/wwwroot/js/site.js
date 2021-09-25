var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ["Remote work", "OnPlaceWork", "Delegations", "Absences"],
        datasets: [{
            data: [55, 10, 10, 25],
            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#36c9cc'],
            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf', '#36c9cc'],
            hoverBorderColor: "rgba(234, 236, 244, 1)",
        }],
    },
    options: {
        maintainAspectRatio: false,
        tooltips: {
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 10,
            yPadding: 10,
            displayColors: false,
            caretPadding: 10,
        },
        legend: {
            display: false
        },
        cutoutPercentage: 70,
    },
});