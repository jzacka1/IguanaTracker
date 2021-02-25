
//fetch coordinates of current device

navigator.geolocation.getCurrentPosition(showPosition, positionError);

function showPosition(position) {
	//var coordinates = position.coords;

	var lat = position.coords.latitude,
		lng = position.coords.longitude,
		city,
		state;

	$.ajax({
		type: "GET",
		url: "https://atlas.microsoft.com/search/address/reverse/json?api-version=1.0&subscription-key=ujITVgwO21SEd9QV0DDVs6PknOGpqpCASaQsA-TYsw0&language=en-US&entityType=Municipality",
		dataType: "json",
		data: { query: lat + ", " + lng },
		success: function (result, status) {
			city = result.addresses[0].address.municipality;
			state = result.addresses[0].address.countrySubdivisionName;

			//Add city and state to form
			$("#City").val(city);
			$("#State").val(state);
		},
		error: function (status, error) {
			alert("Result: " + status + " " + error);
		}
	});

	//Add position coordinates for the location of iguanas
	$("#Latitude").val(lat);
	$("#Longitude").val(lng);
}

function positionError(position) {
	alert("Oops!  Error:  " + position.code);
}