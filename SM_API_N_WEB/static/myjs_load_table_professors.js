// Handle fancy hover button mouse tracking
var buttons = document.querySelectorAll('.fancy-hover-btn');
buttons.forEach(function (btn) {
  btn.addEventListener('mousemove', function (event) {
    var rect = btn.getBoundingClientRect();
    var x = event.clientX - rect.left;
    var y = event.clientY - rect.top;
    btn.style.setProperty('--x', x + 'px');
    btn.style.setProperty('--y', y + 'px');
  });
});

// Initialize global variables
var originalData = [];
var intervalId = null;

// Render the table using the given data array
function renderTable(dataArr) {
  var rfidBody = document.getElementById('rfidBody');
  var rfidMsg = document.getElementById('rfidMsg');

  rfidBody.innerHTML = '';

  if (dataArr.length === 0) {
    rfidMsg.textContent = 'No scans found.';
    return;
  }

  dataArr.forEach(function (row) {
    var tr = document.createElement('tr');

    tr.innerHTML =
      '<td>' + row.school_id + '</td>' +
      '<td>' + row.lname + '</td>' +
      '<td>' + row.fname + '</td>' +
      '<td>' + row.lab_name + '</td>' +
      '<td>' + row.logs_date + '</td>';

    rfidBody.appendChild(tr);
  });

  rfidMsg.textContent = 'Showing ' + dataArr.length + ' result(s).';
}

// Fetch and load data from /api/data if student tab is active
function loadDataRFID() {
  var studentBtn = document.getElementById('btn_student');
  if (!studentBtn.classList.contains('active')) {
    return;
  }

  fetch('/api/data/professors')
    .then(function (res) {
      if (!res.ok) {
        throw new Error('Network error');
      }
      return res.json();
    })
    .then(function (dataArr) {
      originalData = dataArr;
      renderTable(dataArr);
    })
    .catch(function (err) {
      var rfidMsg = document.getElementById('rfidMsg');
      rfidMsg.textContent = 'Error loading data.';
      console.error(err);
    });
}

// On DOM ready, start loading and refreshing data
document.addEventListener('DOMContentLoaded', function () {
  loadDataRFID();
  intervalId = setInterval(loadDataRFID, 5000);
});

// Search button click handler
document.getElementById("searchBtn").addEventListener("click", function () {
  var queryInput = document.getElementById("searchInput");
  var query = queryInput.value.trim();

  if (!query) {
    renderTable(originalData);
    return;
  }

  if (intervalId !== null) {
    clearInterval(intervalId);
    intervalId = null;
  }

  fetch("/search/professors", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ query: query })
  })
    .then(function (response) {
      return response.json();
    })
    .then(function (data) {
      renderTable(data);
    })
    .catch(function (error) {
      var rfidMsg = document.getElementById("rfidMsg");
      rfidMsg.textContent = "Error retrieving search result.";
      console.error("Error:", error);
    });
});

// Clear search button click handler
document.getElementById("clearSearchBtn").addEventListener("click", function () {
  document.getElementById("searchInput").value = '';
  renderTable(originalData);

  if (intervalId === null) {
    intervalId = setInterval(loadDataRFID, 5000);
  }
});
