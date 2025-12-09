-- ================================================
-- UPDATE CF PAKAR (EXPERT WEIGHTS)
-- Purpose: Assign realistic confidence values (0.0 - 1.0)
-- Strategy:
-- 0.8 - 0.9: Very Strong Indicator (Specific Tech/Task)
-- 0.6 - 0.7: Strong Indicator (General Preference)
-- 0.4 - 0.5: Moderate Indicator (Generic/Overlapping)
-- ================================================
USE SistemPakarSkripsi;
GO
-- ================================================
-- LEVEL 1: TOPIK UTAMA
-- ================================================
-- 1. Machine Learning (Q1-Q6)
-- Q1: Dataset besar & Python/R -> Very Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 1;
-- Q2: GPU/Komputasi berat -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 2;
-- Q3: Tuning parameter -> Moderate (0.6)
UPDATE question_rules SET cf_pakar = 0.6 WHERE question_id = 3;
-- Q4: Grafik performa/Log -> Moderate (0.5) (Shared with Data Science)
UPDATE question_rules SET cf_pakar = 0.5 WHERE question_id = 4;
-- Q5: Input-Output Cerdas -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 5;
-- Q6: Environment/Docker -> Weak (0.4) (Shared with DevOps)
UPDATE question_rules SET cf_pakar = 0.4 WHERE question_id = 6;
-- 2. Software Development (Q7-Q12)
-- Q7: Arsitektur Modular -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 7;
-- Q8: Debugging -> Moderate (0.5) (All devs do this)
UPDATE question_rules SET cf_pakar = 0.5 WHERE question_id = 8;
-- Q9: Struktur Code -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 9;
-- Q10: Automation Script -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 10;
-- Q11: Clean Code -> Strong (0.6)
UPDATE question_rules SET cf_pakar = 0.6 WHERE question_id = 11;
-- Q12: Components/Services -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 12;
-- 3. Network Engineer (Q13-Q18)
-- Q13: Router/Switch -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 13;
-- Q14: Wireshark/Packet -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 14;
-- Q15: Troubleshooting Latency -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 15;
-- Q16: VLAN/ACL -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 16;
-- Q17: Protocols (TCP/IP) -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 17;
-- Q18: Uptime/Infra -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 18;
-- 4. UI/UX Designer (Q19-Q24)
-- Q19: Wireframe/Prototype -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 19;
-- Q20: Usability Testing -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 20;
-- Q21: Design System -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 21;
-- Q22: UX Efficiency -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 22;
-- Q23: Clean Design -> Moderate (0.6)
UPDATE question_rules SET cf_pakar = 0.6 WHERE question_id = 23;
-- Q24: Figma/Tools -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 24;
-- ================================================
-- LEVEL 1: METODE (Q25-Q30)
-- ================================================
-- KUALITATIF
-- Q25: Alasan di balik fenomena -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 25;
-- Q26: Data naratif/wawancara -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 26;
-- Q27: Sudut pandang informan -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 27;
-- KUANTITATIF
-- Q28: Data statistik terukur -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 28;
-- Q29: Analisis matematis -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 29;
-- Q30: Survei terstruktur -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 30;
-- ================================================
-- LEVEL 1: REKOMENDASI (Q31-Q36)
-- ================================================
-- MEMBUAT APLIKASI
-- Q31: Produk usable -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 31;
-- Q32: Prototipe berfungsi -> Very Strong (0.9)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 32;
-- Q33: Solusi teknologi nyata -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 33;
-- ANALISIS SISTEM
-- Q34: Bongkar sistem/security -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 34;
-- Q35: Komparasi performa -> Strong (0.8)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 35;
-- Q36: Root cause kegagalan -> Strong (0.7)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 36;
-- ================================================
-- LEVEL 2: SUBTOPIKS (Q37-Q96)
-- Because subtopics are very specific, weights are generally higher (0.7 - 0.9)
-- ================================================
-- Machine Learning Subtopics
-- CV (Q37-39): Pixels (0.8), Objects (0.9), Motion (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 37;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 38;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 39;
-- NLP (Q40-42): Grammar (0.7), Summary (0.8), Embedding (0.9)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 40;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 41;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 42;
-- Data Science (Q43-45): Model (0.8), Feature Eng (0.8), Metrics (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 43;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 44;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 45;
-- MLOps (Q46-48): Production (0.9), Pipeline (0.8), Versioning (0.7)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 46;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 47;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 48;
-- Fuzzy (Q49-51): Non-binary (0.8), IF-THEN (0.9), Reasoning (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 49;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 50;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 51;
-- Software Dev Subtopics
-- Backend (Q52-54): Logic (0.7), API (0.9), Performance (0.8)
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 52;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 53;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 54;
-- Fullstack (Q55-57): End-to-end (0.8), Frontend+Backend (0.9), Debugging (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 55;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 56;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 57;
-- Mobile (Q58-60): UI/Touch (0.8), Sensors (0.9), Battery (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 58;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 59;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 60;
-- DB (Q61-63): Schema (0.8), Query (0.8), Transactions (0.9)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 61;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 62;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 63;
-- Architecture (Q64-66): Communication (0.8), Scaling (0.9), Trade-offs (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 64;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 65;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 66;
-- Network Subtopics
-- Routing (Q67-69): Config (0.9), Loops (0.8), Topology (0.8)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 67;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 68;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 69;
-- NetSec (Q70-72): Firewall (0.9), Traffic Analysis (0.8), Defense (0.8)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 70;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 71;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 72;
-- Server (Q73-75): OS/Service (0.8), Tuning (0.8), HA (0.9)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 73;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 74;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 75;
-- Monitoring (Q76-78): SNMP (0.9), Automation (0.8), Logs (0.7)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 76;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 77;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 78;
-- Wireless (Q79-81): Config (0.8), IoT (0.9), Interference (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 79;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 80;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 81;
-- Designer Subtopics
-- Research (Q82-84): Interview (0.9), Psychology (0.7), Insight (0.8)
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 82;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 83;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 84;
-- Prototyping (Q85-87): Hi-Fi (0.8), Interaction (0.8), Tools (0.9)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 85;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 86;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 87;
-- Design Sys (Q88-90): Rules (0.8), Components (0.9), Docs (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 88;
UPDATE question_rules SET cf_pakar = 0.9 WHERE question_id = 89;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 90;
-- Interaction (Q91-93): Response (0.8), Flow (0.8), Feedback (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 91;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 92;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 93;
-- Product (Q94-96): Journey (0.8), Feasibility (0.8), Business (0.7)
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 94;
UPDATE question_rules SET cf_pakar = 0.8 WHERE question_id = 95;
UPDATE question_rules SET cf_pakar = 0.7 WHERE question_id = 96;
PRINT 'CF Weights updated successfully!';
GO