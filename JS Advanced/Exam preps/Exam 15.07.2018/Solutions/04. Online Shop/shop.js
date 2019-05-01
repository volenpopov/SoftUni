function onlineShop(selector) {
    let form = `<div id="header">Online Shop Inventory</div>
    <div class="block">
        <label class="field">Product details:</label>
        <br>
        <input placeholder="Enter product" class="custom-select">
        <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
        <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
        <button id="submit" class="button" disabled>Submit</button>
        <br><br>
        <label class="field">Inventory:</label>
        <br>
        <ul class="display">
        </ul>
        <br>
        <label class="field">Capacity:</label><input id="capacity" readonly>
        <label class="field">(maximum capacity is 150 items.)</label>
        <br>
        <label class="field">Price:</label><input id="sum" readonly>
        <label class="field">BGN</label>
    </div>`;
    $(selector).html(form);
    
    //-------------
    let submitBtn = document.getElementById('submit');
    let inventory = document.querySelector('ul.display');
    let totalPriceEl = document.getElementById('sum');
    let totalQuantityEl = document.getElementById('capacity');
    
    let productPriceEl = document.getElementById('price');
    let productQuantityEl = document.getElementById('quantity');
    let productNameEl = document.querySelector('input.custom-select');

    let disabledAttribute = document.createAttribute('disabled');
    productNameEl.addEventListener('input', () => {
        let emptyInput = productNameEl.value.trim() === '';
        
        if (emptyInput) {
            submitBtn.disabled = true;
        } else {
            submitBtn.disabled = false;
        }             
    });
        
    submitBtn.addEventListener('click', onSubmit);
    let totalQuantity = 0;
    let totalPrice = 0;

    function onSubmit() {        
        if (totalQuantity < 150) {
        let name = productNameEl.value;
        let price = +productPriceEl.value;
        let quantity = +productQuantityEl.value;

        let li = document.createElement('li');
        li.textContent = `Product: ${name} Price: ${price} Quantity: ${quantity}`;

        inventory.appendChild(li);

        totalQuantity += quantity;
        totalPrice += price;

            totalQuantityEl.value = totalQuantity;            
        } else {
            closeShop();            
        }
        
        totalPriceEl.value = totalPrice;

        resetInputFields();
    }

    function resetInputFields() {
        productNameEl.value = '';
        productPriceEl.value = 1;
        productQuantityEl.value = 1;
    }

    function closeShop() {
        totalQuantityEl.value = 'full';
        totalQuantityEl.classList.add('fullCapacity');

        submitBtn.disabled = true;
        productNameEl.disabled = true;
        productPriceEl.disabled = true;
        productQuantityEl.disabled = true;
    }
    
}
