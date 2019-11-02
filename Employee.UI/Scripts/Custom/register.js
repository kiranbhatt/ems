



class EmployeeRegister {
    constructor() {

    }
    PopulatePermanentAddress() {


        if (document.getElementById('IsAddressSame').checked) {
            document.getElementById('PermanentState').value = document.getElementById('CurrentState').value;
            document.getElementById('PermanentCity').value = document.getElementById('CurrentCity').value;
            document.getElementById('PermanentAddress').value = document.getElementById('CurrentAddress').value;
        }

        else {
            document.getElementById('PermanentState').value = "";
            document.getElementById('PermanentCity').value = "";
            document.getElementById('PermanentAddress').value = "";
        }
    }
    PopulateCities(state) {
        alert(state);
        var id = $('#' + state).val();
        alert(id);

        $.get("https://localhost:44350/Home/CitiesByStateId", { stateId: id }, function (data) {
            var v = "<option>---Select---</option>";
            console.log(JSON.stringify(data));

            $.each(data, function (i, v1) {
                v += "<option value=" + v1.Id + ">" + v1.Name + "</option>";
            });
            $("#CurrentCity").html(v);

        });

    }
    PopulatePermanentCities(state) {
        
        var id = $('#' + state).val();
    

        $.get("https://localhost:44350/Home/CitiesByStateId", { stateId: id }, function (data) {
            var v = "<option>---Select---</option>";
            console.log(JSON.stringify(data));

            $.each(data, function (i, v1) {
                v += "<option value=" + v1.Id + ">" + v1.Name + "</option>";
            });
            $("#PermanentCity").html(v);

        });

    }
}
