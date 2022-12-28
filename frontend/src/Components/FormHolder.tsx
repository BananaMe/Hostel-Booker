import { createOptions, Select } from "@thisbeyond/solid-select";
import { Button, Form } from "solid-bootstrap";
import { Component, createEffect, createSignal, For } from "solid-js";
import { createStore } from "solid-js/store";



const FormHolder: Component = () => {

    // POST method for adding Hostel Name
    const onSubmitHostelName = (e: any) => {
        e.preventDefault();
        console.log(hostelFormData.hostelName);

        fetch(
            "/api/hostel/add_hostel",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(hostelFormData.hostelName)
            })
            .catch(
                (error) => console.log(error) // Handle the error response object
            );
    }

    // POST method for adding Room Number and Guest Capacity
    const onSubmitRoom = (e: any) => {
        e.preventDefault();
        console.log(hostelFormData.roomNumber);
        console.log(hostelFormData.guestCapacity);
        fetch(
            "/api/hostel/add_room",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    roomNumber: hostelFormData.roomNumber,
                    guestCapacity: hostelFormData.guestCapacity
                })
            })
            .catch(
                (error) => console.log(error) // Handle the error response object
            );
    }

    // POST method for adding Reservation, start date and end date
    const onSubmitReservation = (e: any) => {
        e.preventDefault();
        console.log(hostelFormData.startDate);
        console.log(hostelFormData.endDate);
        fetch(
            "/api/room/add_reservation",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    roomNumber: hostelFormData.startDate,
                    guestCapacity: hostelFormData.endDate
                })
            })
            .catch(
                (error) => console.log(error) // Handle the error response object
            );
    }

    // POST method for adding Guest, guest name
    const onSubmitGuestName = (e: any) => {
        e.preventDefault();
        console.log(hostelFormData.guestName);
        fetch(
            "/api/guest/add_guest",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(hostelFormData.guestName)
            })
            .catch(
                (error) => console.log(error) // Handle the error response object
            );
    }

    const getHostels = () => {
        fetch(
            "api/hostel/get_all_hostels",
            {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                },
            }
        )
            .then(
                (response) => response.json() // if the response is a JSON object
            )
            .then(setHostelList)
            .catch(
                (error) => console.log(error) // Handle the error response object
            );
    }

    const [hostelList, setHostelList] = createSignal<any>([]);
    const [hostelFormData, setHostelFormData] = createStore<any>({});
    createEffect(getHostels);
    const hostelOptions = createOptions(hostelList(), { key: "name" });

    return (
        <div>
            <Form>
                <Form.Group class="mb-3" controlId="formHostelName">
                    <Form.Label>Add Hostel </Form.Label>
                    <Form.Control type="text" placeholder="string" name="hostelName" onChange={(e: any) => setHostelFormData("hostelName", e.target.value)} />
                </Form.Group>

                <Button variant="primary" type="submit" onClick={onSubmitHostelName}>Submit</Button>

                <Form.Group class="mb-3" controlId="formRoom">
                    <Form.Label>Add Room </Form.Label>

                    <Select {...hostelOptions} />
                    <Form.Control type="number" placeholder="integer" name="roomNumber" onChange={(e: any) => setHostelFormData("roomNumber", e.target.value)} />
                    <Form.Text class="text-muted">Enter room number</Form.Text>

                    <Form.Control type="number" placeholder="integer" name="guestCapacity" onChange={(e: any) => setHostelFormData("guestCapacity", e.target.value)} />
                    <Form.Text class="text-muted">Enter guest capacity</Form.Text>
                </Form.Group>

                <Button variant="primary" type="submit" onClick={onSubmitRoom}>Submit</Button>

                <Form.Group class="mb-3" controlId="formReservation">
                    <Form.Label>Add Reservation </Form.Label>
                    <Form.Control type="date" placeholder="yyyy-mm-dd" name="startDate" onChange={(e: any) => setHostelFormData("startDate", e.target.value)} />
                    <Form.Text class="text-muted">Enter start date</Form.Text>

                    <Form.Control type="date" placeholder="yyyy-mm-dd" name="endDate" onChange={(e: any) => setHostelFormData("endDate", e.target.value)} />
                    <Form.Text class="text-muted">Enter end date</Form.Text>
                </Form.Group>

                <Button variant="primary" type="submit" onClick={onSubmitReservation}>Submit</Button>

                <Form.Group class="mb-3" controlId="formGuest">
                    <Form.Label>Add Guest </Form.Label>
                    <Form.Control type="text" placeholder="string" name="guestName" onChange={(e: any) => setHostelFormData("guestName", e.target.value)} />
                    <Form.Text class="text-muted">Enter guest name</Form.Text>
                </Form.Group>

                <Button variant="primary" type="submit" onClick={onSubmitGuestName}>Submit</Button>
            </Form>
        </div>
    );
};

export default FormHolder;