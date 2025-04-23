

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let map = L.map('map').setView([0, 0], 2); // Default view

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);


let marker;

var circle;


function findLocation() {
  
    const lat = parseFloat(document.getElementById("Latitude").value);
    const long = parseFloat(document.getElementById("Longitude").value);


    const notification = document.getElementById("notification");
    const notificationMessage = document.getElementById("notificationMessage");
    const notificationIcon = document.getElementById("notificationIcon");
    const progressBarFill = document.getElementById("progressBarFill");

  
    if (!isNaN(lat) && lat >= -90 && lat <= 90 && !isNaN(long) && long >= -180 && long <= 180) {

        notification.className = "notification success";
        icon = "✔️";
        message = "Your action was successful!";
        map.setView([lat, long], 13);

     
        if (marker) {
            map.removeLayer(marker);
        }

     
        marker = L.marker([lat, long]).addTo(map)
            .bindPopup(`Coordinates: (${lat}, ${long})`)
            .openPopup();

        
    } else {
        notification.className = "notification error";
        icon = "❌";
        message = "Invalid latitude/longitude or empty name!";
    }


    notificationIcon.textContent = icon;
    notificationMessage.textContent = message;


    notification.style.right = "20px";


    progressBarFill.style.transition = 'none';
    progressBarFill.style.width = '100%';
    setTimeout(() => {
        progressBarFill.style.transition = 'width 1.2s linear';
        progressBarFill.style.width = '0%';
    }, 10);

    setTimeout(() => {
        hideNotification();
        document.getElementById("myForm").submit();
    }, 1200);

  
}

function findLocationBtn(lat ,long) {

    map.setView([lat, long], 13);


    if (marker) {
        map.removeLayer(marker);
    }


    marker = L.marker([lat, long]).addTo(map)
        .bindPopup(`Coordinates: (${lat}, ${long})`)
        .openPopup();
   
}

function find() {


    const latitude = parseFloat(document.getElementById("Latitude").value);
    const longitude = parseFloat(document.getElementById("Longitude").value);
   

    let icon, message;


    if (validateLatLng(latitude, longitude)) {

        map.setView([latitude, longitude], 13);


        if (marker) {
            map.removeLayer(marker);
        }

        marker = L.marker([latitude, longitude]).addTo(map)
            .bindPopup(`Coordinates: (${latitude}, ${longitude})`)
            .openPopup();

        L.circle([latitude, longitude], {
            color: 'red',
            fillColor: '#f03',
            fillOpacity: 0.5,
            radius: 500
        }).addTo(map);
       
        alert("✅ Success: Your action was successful!");

    } else {
        alert("❌ Error:  Invalid latitude or longitude!" );
    }


  
}



let coordinates = JSON.parse(localStorage.getItem("coordinates")) || [] ;
function removeData() {
    localStorage.removeItem("coordinates");
   coordinates = JSON.parse(localStorage.getItem("coordinates")) || [];
}


function addCoordinate(lat, long) {

    
    const exists = coordinates.some(coord => coord.lat === lat && coord.long === long);
    if (!exists) {
        // Add the new coordinate to the array
        coordinates.push({ lat: lat, long: long });
       
        // Save the updated array back to localStorage
        localStorage.setItem("coordinates", JSON.stringify(coordinates));
        return true;
    } else {
        return false;
    }
}

function deleteCoordinate(lat, long) {


    coordinates.filter(coord => !(coord.lat === lat && coord.long === long));

    coordinates = JSON.parse(localStorage.getItem("coordinates")) || [];
    const exists = coordinates.some(coord => coord.lat === lat && coord.long === long);


    if (!exists) {

        localStorage.setItem("coordinates", JSON.stringify(coordinates));

        return true;
    } else {

        return false;
    }

}

function showNotification(event) {
    event.preventDefault();

    const notification = document.getElementById("notification");
    const notificationMessage = document.getElementById("notificationMessage");
    const notificationIcon = document.getElementById("notificationIcon");
    const progressBarFill = document.getElementById("progressBarFill");

    const Name = document.getElementById("PlaceName").value;
    const latitude = parseFloat(document.getElementById("Latitude").value);
    const longitude = parseFloat(document.getElementById("Longitude").value);

       
    let icon, message;


    if (validateLatLng(latitude, longitude) && Name.trim() !== "") {

        var found = addCoordinate(latitude, longitude);
        if (found) {
            notification.className = "notification success";
            icon = "✔️";
            message = "Your action was successful!";
            
        } else {
            notification.className = "notification warning";
            icon = "    ";
            message = "Location already exists!";
        }
    } else {
        notification.className = "notification error";
        icon = "❌";
        message = "Invalid latitude or longitude!";
    }


    notificationIcon.textContent = icon;
    notificationMessage.textContent = message;


    notification.style.right = "20px";


    progressBarFill.style.transition = 'none';
    progressBarFill.style.width = '100%';
    setTimeout(() => {
        progressBarFill.style.transition = 'width 1.2s linear';
        progressBarFill.style.width = '0%';
    }, 10);

    setTimeout(() => {
        hideNotification();
        document.getElementById("myForm").submit();
    }, 1200);

    return false;
}


function validateLatLng(lat, lng) {
    return !isNaN(lat) && lat >= -90 && lat <= 90 && !isNaN(lng) && lng >= -180 && lng <= 180;
}

function hideNotification() {
    const notification = document.getElementById("notification");
    notification.style.right = "-350px";
}


function showPopup() {
    document.getElementById("popup").classList.add("show");
    document.getElementById("overlay").classList.add("show");
}

function closePopup() {
    document.getElementById("popup").classList.remove("show");
    document.getElementById("overlay").classList.remove("show");
}

function submitUpdate(event) {
    event.preventDefault();

    const data = document.getElementById("dataField").value;
    const date = document.getElementById("dateField").value;

    alert(`Data Updated: ${data}, Date: ${date}`);
    closePopup();
}


