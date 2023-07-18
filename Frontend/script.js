$(document).ready(function() {
  // Fetch rooms based on user role
  var url = "https://localhost:7066/api/rooms";


  $.ajax({
    url: url,
    type: "GET",
    success: function(data) {
      displayRooms(data);
    },
    error: function(error) {
      console.log("Error fetching rooms:", error);
    }
  });
});

function displayRooms(rooms) {
  var roomList = $("#roomList");
  roomList.empty();

  $.each(rooms, function(index, room) {
    var roomItem = $("<div>");
    roomItem.append("<h3>" + room.name + "</h3>");
    roomItem.append("<p>Location: " + room.location + "</p>");
    roomItem.append("<p>Capacity: " + room.capacity + "</p>");
    roomItem.append("<p>Description: " + room.description + "</p>");

    roomList.append(roomItem);
  });
}


