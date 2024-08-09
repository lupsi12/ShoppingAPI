import { useEffect, useState } from "react";
import Layout from "../components/layout/Layout";
import '../styles/Home.css';
import { info } from '../info/info.jsx';
import IconButton from '@mui/material/IconButton';
import RightIcon from '@mui/icons-material/ChevronRight';
import LeftIcon from '@mui/icons-material/ChevronLeft';
 
import { fetchData, deleteData } from '../api/FetchAPI';
import { useNavigate } from "react-router-dom";
import { Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
 
const Home = () => {
 
    const [sliderAdvertisementData,setSliderAdvertisementData]=useState(info.advertisement[0])
 
    const [miniAds, setMiniAds] = useState([]);
 
    useEffect(() => {
        setMiniAds(info.mini_advertisement);
    }, []);
 
    const [advertisement, setAdvertisement] = useState([]);
 
    useEffect(() => {
        setAdvertisement(info.advertisement);
    }, []);
 
    const [currentIndex, setCurrentIndex] = useState(0);
 
    const handlePrev = () => {
        setCurrentIndex((prevIndex) => {
            // Ensure currentIndex does not go below 0
            const newIndex = Math.max(prevIndex - 1, 0);
            return newIndex;
        });
    };
   
    const handleNext = () => {
        setCurrentIndex((prevIndex) => {
            // Ensure currentIndex does not go beyond the last set of items
            const maxIndex = Math.max(advertisement.length - 4, 0);
            const newIndex = Math.min(prevIndex + 1, maxIndex);
            return newIndex;
        });
    };
 
    const handleAdClick = (adId) => {
        // ID'ye göre reklam verisini bul
        const selectedAd = advertisement.find(ad => ad.id === adId);
        if (selectedAd) {
            setSliderAdvertisementData(selectedAd);
        }
    };
 
    return (
        <Layout>
            <div className="home">
                <div className="title">
                   <h1>SKRİLL Hoşgeldiniz</h1>
                </div>
                <div className="home-main">
                    <div className="home-left">
                         <img src={sliderAdvertisementData.img} alt={`Advertisement ${sliderAdvertisementData.id}`} />
                         <p>{sliderAdvertisementData.desciription}</p>
                    </div>
                    <div className="home-right">
                        {miniAds.map((ad) =>
                        (
                            <div key={ad.id} className="mini-ad">
                                <img src={ad.image} alt={`Mini Advertisement ${ad.id}`} />
                            </div>
                        )
                        )
                        }
                    </div>
                </div>
 
                <div className="advertisement-main">
                    <IconButton onClick={handlePrev}>
                        <LeftIcon style={{ color: 'rgba(134,33,101,255)' , fontSize: '30px', marginRight: '10px',marginLeft: '12px', paddingTop: '4px' }} />
                    </IconButton>
                    <div className="slider">
                        {advertisement.slice(currentIndex, currentIndex + 4).map((ad) => (
                            <div key={ad.id}  onClick={() => handleAdClick(ad.id)} className="advertisement">
                                <img src={ad.img} alt={`Advertisement ${ad.id}`} />
                                <p>{ad.desciription}</p>
                            </div>
                        ))}
                    </div>
                    <IconButton onClick={handleNext} >
                        <RightIcon style={{ color: 'rgba(134,33,101,255)' , fontSize: '30px', marginLeft: '10px', paddingTop: '4px' }}/>
                    </IconButton>
                    <div className="advertisement-right"/>
                   
                </div>
            </div>
        </Layout>
    );
}
export default Home;