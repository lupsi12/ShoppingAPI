import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import Create from "./pages/Create";
import Deneme from "./pages/Deneme";
import Contact from "./pages/Contact";

function App() {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route path="/deneme" element={<Deneme/>}/>
                    <Route path="/" element={<Home/>}/>
                    <Route path="/create" element={<Create/>}/>
                    <Route path="/bize-ulasin" element={<Contact/>}/>
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
