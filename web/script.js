async function createOrder() {
    const productId = document.getElementById("productId").value;
    const productName = document.getElementById("productName").value;
    const quantity = document.getElementById("quantity").value;
    const address = document.getElementById("address").value;
    const phoneNumber = document.getElementById("phoneNumber").value;
    const timeShip = document.getElementById("timeShip").value;

    const orderDto = {
        ProductName: productName,
        QuantityOrder: quantity,
        Adress: address,
        PhoneNuber: phoneNumber,
        TimeShip: timeShip,
    };

    try {
        const response = await fetch(`https://localhost:7082/api/Order/create/${productId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(orderDto),
        });

        if (response.ok) {
            const createdOrder = await response.json();
            console.log("Order created:", createdOrder);
            // Update UI as needed
        } else {
            const errorData = await response.json();
            console.error("Error creating order:", errorData);
            // Handle error and update UI
        }
    } catch (error) {
        console.error("An error occurred:", error);
        // Handle error and update UI
    }
}

async function deleteOrder() {
    const orderIdToDelete = document.getElementById("orderIdToDelete").value;

    try {
        const response = await fetch(`https://localhost:7082/api/Order/${orderIdToDelete}`, {
            method: 'DELETE',
        });

        if (response.ok) {
            const result = await response.text();
            console.log(result);
            // Update UI as needed
        } else {
            const errorData = await response.json();
            console.error("Error deleting order:", errorData);
            // Handle error and update UI
        }
    } catch (error) {
        console.error("An error occurred:", error);
        // Handle error and update UI
    }
}

async function updateOrder() {
    const orderIdToUpdate = document.getElementById("orderIdToUpdate").value;
    const updatedAddress = document.getElementById("updatedAddress").value;
    const updatedPhoneNumber = document.getElementById("updatedPhoneNumber").value;
    const updatedTimeShip = document.getElementById("updatedTimeShip").value;

    const updatedOrderDto = {
        Adress: updatedAddress,
        PhoneNuber: updatedPhoneNumber,
        TimeShip: updatedTimeShip,
    };

    try {
        const response = await fetch(`https://localhost:7082/api/Order/${orderIdToUpdate}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(updatedOrderDto),
        });

        if (response.ok) {
            const result = await response.text();
            console.log(result);
            // Update UI as needed
        } else {
            const errorData = await response.json();
            console.error("Error updating order:", errorData);
            // Handle error and update UI
        }
    } catch (error) {
        console.error("An error occurred:", error);
        // Handle error and update UI
    }
}

async function getAllOrders() {
    try {
        const response = await fetch('https://localhost:7082/api/Order/all');

        if (response.ok) {
            const allOrders = await response.json();
            console.log("All Orders:", allOrders);
            // Update UI as needed
            document.getElementById("allOrdersResult").innerText = JSON.stringify(allOrders, null, 2);
        } else {
            const errorData = await response.json();
            console.error("Error getting all orders:", errorData);
            // Handle error and update UI
        }
    } catch (error) {
        console.error("An error occurred:", error);
        // Handle error and update UI
    }
}
